# MarsPuppies

## Workflow

### Monolith

| Overarching |Step     |Explanation     |Is forced to pass     |
|----------------|---------------|--------------|--|
|CI| Build| Bye|:heavy_check_mark:|
||Test| efe |:wavy_dash: <br /> (Above certain score)|
||Static code review|sonarcloud-scans|:wavy_dash: <br /> Above certain score|
|CD| Dockerize | ef|:heavy_check_mark:|
|| Push to Docker| deef|:heavy_check_mark:|
||Push to ACR| Azure Container Registry|:heavy_check_mark:|


### Microservice
| Overarching |Step     |Explanation     |Is forced to pass     |
|----------------|---------------|--------------|--|
|CI| Build| Bye|:heavy_check_mark:|
||Test| efe |:wavy_dash: <br /> (Above certain score)|
||Static code review|sonarcloud-scans|:wavy_dash: <br /> Above certain score|
|CD| Dockerize | ef|:heavy_check_mark:|
|| Push to Docker| deef|:heavy_check_mark:|
||Push to ACR| Azure Container Registry|:x:|
||Push to AKS | Azure Kubernetes Service|:heavy_check_mark:|

ACR is optional, as the containers is pulled from hub.docker.com, but its possible to switch it up when the situation demands it.


