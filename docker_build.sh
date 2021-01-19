#!/bin/bash

echo "Docker build"

GITHUB_URL_WITH_TOKEN=$1

docker build -f SIGO.Normas/Dockerfile $GITHUB_URL_WITH_TOKEN -t sigo/normas:dev
docker build -f SIGO.WebSite/Dockerfile $GITHUB_URL_WITH_TOKEN -t sigo/website:dev
