# Blazor WASM Headless CMS with AutoRest #

This provides sample code for Blazor WASM app that builds a headless CMS, using AutoRest.


## Prerequisites ##

* [.NET 6 or later](https://dotnet.microsoft.com/en-us/download/dotnet/6.0?WT.mc_id=dotnet-68007-juyoo)
* [Visual Studio Code](https://code.visualstudio.com/?WT.mc_id=dotnet-68007-juyoo)
* [Azure Account (Free)](https://azure.microsoft.com/free/?WT.mc_id=dotnet-68007-juyoo)
* [Azure CLI](https://docs.microsoft.com/cli/azure/install-azure-cli?WT.mc_id=dotnet-68007-juyoo)
* [Azure Static Web Apps CLI](https://github.com/Azure/static-web-apps-cli)
* [AutoRest](https://github.com/Azure/autorest)


## Getting Started ##

### Azure Static Web App Instance ###

1. Update `appsettings.sample.json` to `appsettings.json`, and replace the `<your_wordpress_site_name>` part with yours.

    ```json
    {
      "SITE__NAME": "<your_wordpress_site_name>.wordpress.com"
    }
    ```

2. Publish the Blazor WASM app.

    ```bash
    cd ./BlazorApp
    dotnet publish . -c Release
    ```

3. Run the following Azure CLI commands.

    ```bash
    resource_group=<resource_group_name>
    swa_name=<staticwebapp_name>
    location=<location>

    # Create a resource group
    az group create -n $resource_group -l $location

    # Provision Azure Static Web App instance
    az staticwebapp create -g $resource_group -n $swa_name -l $location

    # Get Azure Static Web App deployment key
    swa_key=$(az staticwebapp secrets list -g $resource_group -n $swa_name --query "properties.apiKey" -o tsv)
    
    # Deploy Azure Static Web App
    swa deploy -a ./bin/Release/net6.0/publish/wwwroot -d $swa_key --env default
    ```
