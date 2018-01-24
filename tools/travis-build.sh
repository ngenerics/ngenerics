#!/bin/sh
cd src

if [ "$TRAVIS_PULL_REQUEST" = "false" ]; then
	mono ../tools/sonar/SonarQube.Scanner.MSBuild.exe begin /n:NGenerics /k:ngenerics-github /d:sonar.login=${SONAR_TOKEN} /d:sonar.host.url="https://sonarcloud.io" /d:sonar.cs.vstest.reportsPaths="**/TestResults/*.trx" /v:"2.0" 
fi

dotnet build
dotnet test NGenerics.Tests --logger:trx
dotnet test NGenerics.Examples --logger:trx

if [ "$TRAVIS_PULL_REQUEST" = "false" ]; then
	mono ../tools/sonar/SonarQube.Scanner.MSBuild.exe end /d:sonar.login=${SONAR_TOKEN}
fi
