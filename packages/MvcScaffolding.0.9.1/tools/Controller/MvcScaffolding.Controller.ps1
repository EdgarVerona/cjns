[T4Scaffolding.Scaffolder(Description = "Allows you to modify the T4 template rendered by a scaffolder")][CmdletBinding()]
param(     
	[parameter(Mandatory = $true, ValueFromPipelineByPropertyName = $true)][string]$ModelType,   
    [string]$Project,
    [string]$CodeLanguage,
	[string]$DbContextType,
	[string]$Area,
	[alias("MasterPage")][string]$Layout,
 	[alias("ContentPlaceholderIDs")][string[]]$SectionNames,
	[alias("PrimaryContentPlaceholderID")][string]$PrimarySectionName,
	[switch]$Repository = $false,
	[switch]$NoChildItems = $false,
	[string[]]$TemplateFolders,
	[switch]$Force = $false
)

if (!((Get-ProjectAspNetMvcVersion -Project $Project) -ge 3)) {
	Write-Error ("Project '$((Get-Project $Project).Name)' is not an ASP.NET MVC 3 project.")
	return
}

$foundModelType = Get-ProjectType $ModelType -Project $Project
if (!$foundModelType) { return }

$primaryKey = Get-PrimaryKey $foundModelType.FullName -Project $Project -ErrorIfNotFound
if (!$primaryKey) { return }

$templateName = if($Repository) { "ControllerWithRepository" } else { "ControllerWithContext" }
$templateFile = Find-ScaffolderTemplate $templateName -TemplateFolders $TemplateFolders -Project $Project -CodeLanguage $CodeLanguage -ErrorIfNotFound
if ($templateFile) {
	$outputPath = Join-Path Controllers ($foundModelType.Name + "Controller")
	# We don't create areas here, so just ensure that if you specify one, it already exists
	if ($Area) {
		$areaPath = Join-Path Areas $Area
		if (-not (Get-ProjectItem $areaPath -Project $Project)) {
			Write-Error "Cannot find area '$Area'. Make sure it exists already."
			return
		}
		$outputPath = Join-Path $areaPath $outputPath
	}

	# Prepare all the parameter values to pass to the template, then invoke the template with those values
	if(!$DbContextType) { $DbContextType = [System.Text.RegularExpressions.Regex]::Replace((Get-Project $Project).Name, "[^a-zA-Z0-9]", "") + "Context" }
	$repositoryName = $foundModelType.Name + "Repository"
	$defaultNamespace = (Get-Project $Project).Properties.Item("DefaultNamespace").Value
	$modelTypeNamespace = [T4Scaffolding.Namespaces]::GetNamespace($foundModelType.FullName)
	$controllerNamespace = [T4Scaffolding.Namespaces]::Normalize($defaultNamespace + "." + [System.IO.Path]::GetDirectoryName($outputPath).Replace([System.IO.Path]::DirectorySeparatorChar, "."))
	$areaNamespace = if ($Area) { [T4Scaffolding.Namespaces]::Normalize($defaultNamespace + ".Areas.$Area") } else { $defaultNamespace }
	$dbContextNamespace = [T4Scaffolding.Namespaces]::Normalize($areaNamespace + ".Models")
	$modelTypePluralized = Get-PluralizedWord $foundModelType.Name
	$wroteFile = Invoke-ScaffoldTemplate -Template $templateFile -Model @{ 
		ModelType = [MarshalByRefObject]$foundModelType; 
		PrimaryKey = [string]$primaryKey; 
		DefaultNamespace = $defaultNamespace; 
		AreaNamespace = $areaNamespace; 
		DbContextNamespace = $dbContextNamespace;
		ModelTypeNamespace = $modelTypeNamespace; 
		ControllerNamespace = $controllerNamespace; 
		DbContextType = $DbContextType; 
		Repository = $repositoryName; 
		ModelTypePluralized = [string]$modelTypePluralized; 
	} -Project $Project -OutputPath $outputPath -Force:$Force 
	if($wroteFile) {
		Write-Host "Added controller '$wroteFile'"
	}

	if (!$NoChildItems) {
		if ($Repository) {
			Scaffold Repository -ModelType $foundModelType.FullName -DbContextType $DbContextType -Area $Area -Project $Project -CodeLanguage $CodeLanguage -Force:$Force
		} else {
			Scaffold DbContext -ModelType $foundModelType.FullName -DbContextType $DbContextType -Area $Area -Project $Project -CodeLanguage $CodeLanguage
		}

		Scaffold Views -Controller $foundModelType.Name -ModelType $foundModelType.FullName -Area $Area -Layout $Layout -SectionNames $SectionNames -PrimarySectionName $PrimarySectionName -Project $Project -CodeLanguage $CodeLanguage -Force:$Force
	}
}