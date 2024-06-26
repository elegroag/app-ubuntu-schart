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
dotnet bin/Debug/net6.0/BackFacture.dll BackFacture.MiClaseEjemplo MiMetodoJson "{\"Nombre\":\"Juan\",\"Edad\":30}" 450 development


dotnet run app.MiClaseEjemplo MiMetodoJson "{\"Nombre\":\"Juan\",\"Edad\":30}" 450 true
dotnet run app.UsuariosController PruebaConnection "{\"Nombre\":\"Juan\",\"Edad\":30}" 450
```

## ODBC Drivers Connector
```sh
sudo apt-get -y install unixodbc

curl https://packages.microsoft.com/keys/microsoft.asc | sudo tee /etc/apt/trusted.gpg.d/microsoft.asc
curl https://packages.microsoft.com/config/ubuntu/$(lsb_release -rs)/prod.list | sudo tee /etc/apt/sources.list.d/mssql-release.list

sudo apt-get update
sudo apt-get install -y msodbcsql18 mssql-tools18
echo 'export PATH="$PATH:/opt/mssql-tools18/bin"' >> ~/.bashrc
source ~/.bashrc

sudo apt-get install -y unixodbc-dev
dotnet add package System.Data.Odbc --version 4.7.0
odbcinst -j

sudo vim /etc/odbc.ini
dotnet remove package System.Data.Odbc --version 4.7.0
sudo -i -u admin
echo "select 1" | isql -v ODBCPostgres
```

# Usando hsqldb IKVM Java
```sh
wget https://sourceforge.net/projects/hsqldb/files/hsqldb/hsqldb_2_7/hsqldb-2.7.3.zip
unzip hsqldb-2.7.3.zip
mv hsqldb-2.7.3/hsqldb/lib/hsqldb.jar ./hsqldb.jar

dotnet add package IKVM --version 8.8.1
```

```xml
<ItemGroup>
  <PackageReference Include="IKVM" Version="8.8.1" />
</ItemGroup>

<ItemGroup>
  <IkvmReference Include="hsqldb.jar" />
</ItemGroup>
```