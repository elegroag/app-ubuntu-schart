# App en c# y ubuntu

- Crear aplicacion de console

## Documentación inicializa proyecto

```sh
    wget https://packages.microsoft.com/config/ubuntu/20.04/packages-microsoft-prod.deb -O packages-microsoft-prod.deb
    sudo dpkg -i packages-microsoft-prod.deb
    rm packages-microsoft-prod.deb

    sudo apt-get update
    sudo apt-get install -y dotnet-sdk-6.0

    sudo apt install zlib1g

    dotnet --version
    dotnet --help

    # Crear el proyecto
    dotnet new console -o sample1

    # O tambien se puede usando -n
    dotnet new console -n BackFacture
    cd BackFacture
    dotnet run

    dotnet run BackFacture.MiClaseEjemplo MiMetodoJson "{\"Nombre\":\"Juan\",\"Edad\":30}" 450 development true

    dotnet list package
    dotnet add package Newtonsoft.Json
    dotnet build
    dotnet /home/elegro/projects/cshart/BackFacture/bin/Debug/net6.0/BackFacture.dll BackFacture.MiClaseEjemplo MiMetodoJson "{\"Nombre\":\"Juan\",\"Edad\":30}" 450 development
```
