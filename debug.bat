@echo off
dotnet build src/Skybrud.Social.Twitter --configuration Debug /t:rebuild /t:pack -p:BuildTools=1 -p:PackageOutputPath=c:/nuget