# Template App

This is an **opinionated** web application template built using .NET 8 and Blazor.

## License

This project is licensed under the [MIT License](LICENSE).

## Contributing

Contributions are welcome, but I don't promise to always have the time to review them!

## Roadmap

There's a lot to do...

- [x] License
- [x] Scaffold Blazor Web App
- [x] Basic IaC setup with Bicep
- [ ] Build definition using NUKE
- [ ] Basic CI/CD setup with Azure DevOps
- [ ] SQL Server and EF Core setup
- [ ] API setup with FastEndpoints
- [ ] API validation with FluentValidation
- [ ] Styling with Tailwind CSS
- [ ] Components with MudBlazor
- [ ] Basic application layout
- [ ] Form infrastructure
- [ ] API request infrastructure
- [ ] Authentication
- [ ] ...

## Infrastructure

The infrastructure for this project is defined using Bicep. To run Bicep you will need:

- An Azure Subscription and a Resource Group within that Subscription
- The Azure CLI command line tool (`az`)

To run Bicep, run the following command from the `/infra` directory (replacing the placeholders with your own values):

```bash
az deployment group create --template-file '.\main.bicep' --parameters '.\parameters\parameters.{env}.bicepparam' -g '{resource-group-name}'
```

## CI/CD

The CI/CD pipeline for this project is defined using Azure DevOps.

In order for the pipeline to run you will first need to:

- Create an Organization and Project within Azure DevOps
- Create a Service Connection within Azure DevOps Project that goes through to your Azure Subscription
  - You can either create a single Service Connection scoped to your Subscription, or create multiple Service Connections scoped to individual Resource Groups (one per logical environment)
  - This template assumes you have created a single Service Connection called `TemplateAppSC` - if you use a different name, you will need to update the Azure Pipelines YAML file as appropriate
- Create the following Environments within your Azure DevOps Project
  - INT (Integration)
  - QA (Quality Assurance)
  - UAT (User Acceptance Testing)
  - PROD (Production)
- For the QA, UAT, and PROD Environments, configure an "Approvals" check to ensure that deployments must be manually promoted
- For the PROD environment, consider adding a "Business Hours" check to ensure that Production deployments happen outside of business hours
