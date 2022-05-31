# Blazor WASM Headless CMS with Azure Functions API #

This provides sample code for Blazor WASM app that builds a headless CMS, with Azure Functions API.


## Prerequisites ##

* [.NET 6 or later](https://dotnet.microsoft.com/en-us/download/dotnet/6.0?WT.mc_id=dotnet-68007-juyoo)
* [Visual Studio Code](https://code.visualstudio.com/?WT.mc_id=dotnet-68007-juyoo)
* [Azure Account (Free)](https://azure.microsoft.com/free/?WT.mc_id=dotnet-68007-juyoo)
* [Azure CLI](https://docs.microsoft.com/cli/azure/install-azure-cli?WT.mc_id=dotnet-68007-juyoo)
* [Azure Static Web Apps CLI](https://github.com/Azure/static-web-apps-cli)


## Getting Started ##

### Install Azure Static Web App (SWA) CLI ###

If you have not already installed the SWA CLI yet, run the following command to install it.

```bash
npm install -g @azure/static-web-apps-cli
```

### Run Blazor WASM App Locally ###

1. Rename `appsettings.sample.json` to `appsettings.json` under the `BlazorApp/wwwroot` directory, and replace the `<your_wordpress_site_name>` part with yours.

    ```json
    {
      "SITE__NAME": "<your_wordpress_site_name>.wordpress.com"
    }
    ```

2. Build the entire solution.

    ```bash
    dotnet restore .
    dotnet build .
    ```

3. Run the SWA CLI command.

    ```bash
    swa start
    ```

4. Open a web browser and go to `http://localhost:4280`


### Build and Deploy App to Azure Static Web App ###

1. Rename `appsettings.sample.json` to `appsettings.json` under the `BlazorApp/wwwroot` directory, and replace the `<your_wordpress_site_name>` part with yours.

    ```json
    {
      "SITE__NAME": "<your_wordpress_site_name>.wordpress.com"
    }
    ```

2. Build the entire solution.

    ```bash
    dotnet restore .
    dotnet build .
    ```

3. Publish the Blazor WASM app.

    ```bash
    dotnet publish ./BlazorApp -c Release -o ./BlazorApp/bin
    ```

4. Run the following Azure CLI commands.

    ```bash
    resource_group=<resource_group_name>
    swa_name=<staticwebapp_name>
    location=<location>

    # Login to Azure
    az login

    # Create a resource group
    az group create -n $resource_group -l $location

    # Provision Azure Static Web App instance
    az staticwebapp create -g $resource_group -n $swa_name -l $location

    # Get Azure Static Web App deployment key
    swa_key=$(az staticwebapp secrets list -g $resource_group -n $swa_name --query "properties.apiKey" -o tsv)
    
    # Deploy Azure Static Web App
    swa deploy -d $swa_key --env default
    ```

5. Open a web browser and go to the URL showing on the terminal.
