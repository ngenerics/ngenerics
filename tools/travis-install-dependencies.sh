#!/bin/sh

# Install a more recent version of Mono
sudo apt-key adv --keyserver hkp://keyserver.ubuntu.com:80 --recv-keys 3FA7E0328081BFF6A14DA29AA6A19B38D3D831EF
echo "deb http://download.mono-project.com/repo/ubuntu trusty main" | sudo tee /etc/apt/sources.list.d/mono-official.list
sudo apt-get -qq update
sudo apt-get install -y mono-complete unzip wget

# Install the MSBuild Sonar scanner
wget -O sonar.zip https://github.com/SonarSource/sonar-scanner-msbuild/releases/download/4.0.2.892/sonar-scanner-msbuild-4.0.2.892.zip
unzip sonar.zip -d tools/sonar
ls -l tools/sonar
chmod +x tools/sonar/sonar-scanner-3.0.3.778/bin/sonar-scanner