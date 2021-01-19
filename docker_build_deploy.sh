#!/bin/bash

echo "Docker build and deploy"

DOCKERFILE_PATH=$1
IMAGE_NAME=$2
CONTAINER_NAME=$3

echo "docker build -f $DOCKERFILE_PATH $GITHUB_URL_WITH_TOKEN -t $IMAGE_NAME"
echo "docker stop $CONTAINER_NAME || true && docker rm $CONTAINER_NAME || true"
echo "docker run --name $CONTAINER_NAME -d -p 52001:443 $IMAGE_NAME"
