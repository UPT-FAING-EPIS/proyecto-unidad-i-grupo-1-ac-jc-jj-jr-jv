@echo off
PowerShell -NoExit -Command "cd '.\proyecto-unidad-i-grupo-1-ac-jc-jj-jr-jv\Gestion de Clientes\ClienteAPI\'; docker rm -f api_clientes; docker rmi gestiondeclientes-api; dotnet clean; dotnet build; docker-compose up -d; pause"
