#!/bin/sh
version=$(xpath -q -e '//PackageVersion/text()' ../src/NGenerics/NGenerics.release.csproj)
dotnet nuget push "../src/NGenerics/bin/release/NGenerics.${version}.nupkg" -s nuget.org -k $NUGET_KEY
