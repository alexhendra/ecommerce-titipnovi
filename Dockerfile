FROM microsoft/dotnet:2.1-sdk AS build

WORKDIR /app
COPY . .

RUN dotnet restore

RUN dotnet publish -c Release -o out

#RUN ls ./

FROM microsoft/dotnet:2.1-aspnetcore-runtime AS runtime

WORKDIR /app

COPY --from=build /app/out  ./

#RUN ls ./

ENTRYPOINT ["dotnet", "titipnovi_aspnetcore_api.dll"]

