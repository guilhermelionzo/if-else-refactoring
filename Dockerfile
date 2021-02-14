FROM sonar-scanner-image:latest AS sonarqube_scan
WORKDIR /app
COPY . .
RUN ls /usr/lib/jvm/java-11-openjdk-amd64/
RUN export JAVA_HOME=/usr/lib/jvm/java-11-openjdk-amd64/
RUN export PATH=$JAVA_HOME/bin:$PATH
RUN env
# We are restoring package here in order to make logs clearer for us to read in sonar-scanner
# analysis execution section
RUN dotnet restore
RUN ls -list
# First difference between this scanner and the previous one is a way that we execute it.
# We need to execute 3 commands in order to trigger an analysis. Firstly we need to begin Sonarqube
# analysis and pass analysis parameters. Then we need to build an application and then finally we need to
# to explicitly end analysis.
# What is more syntax of passing parameters varies from the previous scanner. We have predefined special
# prefixes for project key, project name and project versions instead of passing them as casual
# parameter. Also instead of adding prefix "/D" for this scanner, we need to ad "/d:" instead.
# The last, but not least difference is that we need to authorize on both begin and end step
# if Sonarqube project is private.
# Except for the above differences other parameters is mostly working the same.
RUN dotnet sonarscanner begin \
/k:"dotnetproject" \
/n:"Project Name" \
/d:sonar.login="1b18fb3d2b2ec12bbbd9cb56aebb1ec6bea2513d" \
/d:sonar.exclusions="**/wwwroot/**, **/obj/**, **/bin/**"
# /v:"SONAR_NET_PROJECT_VERSION" \
# /d:sonar.links.homepage="CI_LINK_URL"
RUN dotnet build --no-incremental
RUN dotnet sonarscanner end /d:sonar.login="1b18fb3d2b2ec12bbbd9cb56aebb1ec6bea2513d"
