#!/bin/bash
cd "${0%/*}"

(trap 'kill 0' SIGINT; bash ./run-client.sh & bash ./run-server.sh)