#!/bin/bash

echo "Docker build and deploy"

GITHUB_URL_WITH_TOKEN=$1
DOCKERFILE_PATH=$2
IMAGE_NAME=$3
CONTAINER_NAME=$4

docker build -f $DOCKERFILE_PATH $GITHUB_URL_WITH_TOKEN -t $IMAGE_NAME
docker stop $CONTAINER_NAME || true && docker rm $CONTAINER_NAME || true
docker run --name $CONTAINER_NAME -d -p 52001:443 $IMAGE_NAME
