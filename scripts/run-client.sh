#!/bin/bash
cd "${0%/*}"
cd "../client"

if command -v yarn &> /dev/null
then
  yarn
  yarn run serve
elif command -v npm &> /dev/null
then
  npm install
  npm run serve
else
  echo "npm or yarn is required to run the client"
  exit 1
fi