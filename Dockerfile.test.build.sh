docker build -f Dockerfile.test.build -t com-Efrata-service-core-webapi:test-build .
docker create --name com-Efrata-service-core-webapi-test-build com-Efrata-service-core-webapi:test-build
mkdir bin
docker cp com-Efrata-service-core-webapi-test-build:/out/. ./bin/publish
docker build -f Dockerfile.test -t com-Efrata-service-core-webapi:test .
