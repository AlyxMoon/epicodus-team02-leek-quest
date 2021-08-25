#!/bin/bash
cd "${0%/*}"
cd "../server"

if command -v dotnet &> /dev/null
then
  dotnet watch run
else
  echo "dotnet is required to run the server"
  exit 1
fi