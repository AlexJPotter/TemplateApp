param location string
param projectName string

module webApp 'modules/webApp.bicep' = {
  name: 'webApp'
  params: {
    location: location
    projectName: projectName
  }
}
