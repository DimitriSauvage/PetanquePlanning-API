FROM mcr.microsoft.com/dotnet/core/sdk:3.1
WORKDIR /app

#Create folder for Tools
RUN mkdir CSharp-Tools

#Copy the tools
COPY ../../CSharp-Tools ./CSharp-Tools

#Copy Application files
COPY ../../PetanquePlanning-API ./PetanquePlanning-API

#Go to the application file 
WORKDIR ./PetanquePlanning-API/PetanquePlanningApi

#Restore packages
RUN dotnet restore

#Publish in Release config, in the "out" folder, and do not restore packages
RUN dotnet publish -c Release -o out --no-restore

ENTRYPOINT ["dotnet",  "out/PetanquePlanningApi.dll"]
