#!/bin/bash
DOCKER_ENV=''
DOCKER_TAG=''
case "$TRAVIS_BRANCH" in
  "master")
    DOCKER_ENV=production
    DOCKER_TAG=latest
    ;;
  "dev")
    DOCKER_ENV=development
    DOCKER_TAG=dev
    ;;    
esac

docker login -u $DOCKER_USERNAME -p $DOCKER_PASSWORD
docker build -f ./src/DriverRatings.Server.Api/Dockerfile.$DOCKER_ENV -t driver-ratings:$DOCKER_TAG ./src/DriverRatings.Server.Api
docker tag driver-ratings:$DOCKER_TAG $DOCKER_USERNAME/driver-ratings:$DOCKER_TAG
docker push $DOCKER_USERNAME/driver-ratings:$DOCKER_TAG