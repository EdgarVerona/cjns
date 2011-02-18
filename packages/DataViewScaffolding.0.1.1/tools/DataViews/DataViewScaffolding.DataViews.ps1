[T4Scaffolding.Scaffolder(Description = "Adds ASP.NET MVC views for Create/Read/Update/Delete/Index scenarios")][CmdletBinding()]
param(        
	[parameter(Mandatory = $true, ValueFromPipelineByPropertyName = $true, Position = 0)][string]$Controller,
	[string]$ModelType,
	[string]$Area,
	[alias("MasterPage")][string]$Layout,	# If not set, we'll use the default layout
 	[alias("ContentPlaceholderIDs")][string[]]$SectionNames,
	[alias("PrimaryContentPlaceholderID")][string]$PrimarySectionName,
    [string]$Project,
	[string]$CodeLanguage,
	[string[]]$TemplateFolders,
	[string]$ViewScaffolder = "",
	[switch]$Force = $false
)


$ViewPageNames = "Details", "Index"
$ViewNames = "Json", "Xml", "Atom"

foreach($ViewPageName in $ViewPageNames)
{
	foreach ($ViewName in $ViewNames)
	{
		Scaffold "DataViewScaffolding.$ViewName" -Controller $Controller -ViewName $ViewPageName -ModelType $ModelType -Template $ViewPageName -Area $Area -Layout $Layout -SectionNames $SectionNames -PrimarySectionName $PrimarySectionName -Project $Project -CodeLanguage $CodeLanguage -OverrideTemplateFolders $TemplateFolders -Force:$Force
	}
}