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
