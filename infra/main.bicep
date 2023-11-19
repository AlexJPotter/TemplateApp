param location string
param projectName string
param environment string

module webApp 'modules/webApp.bicep' = {
  name: 'webApp'
  params: {
    location: location
    projectName: projectName
    environment: environment
  }
}
