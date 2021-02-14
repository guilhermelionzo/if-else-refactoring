#https://blog.setapp.pl/how-to-use-sonarscanner
#dotnet project b50fd8b939923a71edd39fd65985599394ddda19
#step 1
docker run -d --name sonarqube -p 9000:9000 sonarqube:7.5-community
       
#step 2
docker build --network=host --tag sonar-scanner-image:latest --build-arg SONAR_HOST="http://localhost:9000" --build-arg SONAR_LOGIN_TOKEN="571fd96ddc93d6599add010ac0624e96a221c167" .
       
#step 3
docker build --network=host --no-cache .
