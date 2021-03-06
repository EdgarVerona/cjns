[T4Scaffolding.Scaffolder(Description = "Adds an ASP.NET MVC view using the Razor view engine")][CmdletBinding()]
param(        
	[parameter(Mandatory = $true, ValueFromPipelineByPropertyName = $true, Position = 0)][string]$Controller,
	[parameter(Mandatory = $true, ValueFromPipelineByPropertyName = $true, Position = 1)][string]$ViewName,
	[string]$ModelType,
	[string]$Template = "Empty",
	[string]$Area,
	[alias("MasterPage")][string]$Layout,	# If not set, we'll use the default layout
 	[string[]]$SectionNames,
	[string]$PrimarySectionName,
    [string]$Project,
	[string]$CodeLanguage,
	[string[]]$TemplateFolders,
	[string]$ViewType,
	[switch]$Force = $false
)

# Ensure this is a valid target project
if (!((Get-ProjectAspNetMvcVersion -Project $Project) -ge 3)) {
	Write-Error ("Project '$((Get-Project $Project).Name)' is not an ASP.NET MVC 3 project.")
	return
}

# Ensure we have a controller name, plus a model type if specified
if ($ModelType) {
	$foundModelType = Get-ProjectType $ModelType -Project $Project
	if (!$foundModelType) { return }
	$primaryKeyName = [string](Get-PrimaryKey $foundModelType.FullName -Project $Project)
}

# Decide where to put the output
$outputFolderName = Join-Path Views $Controller
$outputFolderName = Join-Path $outputFolderName "Json"


if ($Area) {
	# We don't create areas here, so just ensure that if you specify one, it already exists
	$areaPath = Join-Path Areas $Area
	if (-not (Get-ProjectItem $areaPath -Project $Project)) {
		Write-Error "Cannot find area '$Area'. Make sure it exists already."
		return
	}
	$outputFolderName = Join-Path $areaPath $outputFolderName
}
$outputPath = Join-Path $outputFolderName $ViewName


# Find the T4 template
$templateFile = Find-ScaffolderTemplate $Template -TemplateFolders $TemplateFolders -Project $Project -CodeLanguage $CodeLanguage -ErrorIfNotFound

Write-Host "FILE CHOSEN: $templateFile"

if ($templateFile) {	
	# Render it, adding the output to the Visual Studio project
	$wroteFile = Invoke-ScaffoldTemplate -Template $templateFile -Model @{ 
		IsContentPage = [bool]$Layout;
		Layout = $Layout;
		SectionNames = $SectionNames;
		PrimarySectionName = $PrimarySectionName;
		ViewName = $ViewName;
		PrimaryKeyName = $primaryKeyName;
		ViewDataType = [MarshalByRefObject]$foundModelType;
		ViewDataTypeName = $foundModelType.Name;
	} -Project $Project -OutputPath $outputPath -Force:$Force

	if($wroteFile) {
		Write-Host "Added $ViewName view at '$wroteFile'"
	}
}