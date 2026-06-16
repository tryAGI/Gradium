#!/usr/bin/env bash
set -euo pipefail
install_autosdk_cli() {
  dotnet tool update --global autosdk.cli --prerelease >/dev/null 2>&1 || \
    dotnet tool install --global autosdk.cli --prerelease
}

fetch_spec() {
  curl "$@" \
    --fail --silent --show-error --location \
    --retry 5 --retry-delay 10 --retry-all-errors \
    --connect-timeout 30 --max-time 300
}

install_autosdk_cli
rm -rf Generated
fetch_spec --fail --silent --show-error --location https://docs.gradium.ai/api-reference/openapi.json -o openapi.yaml

autosdk generate openapi.yaml \
  --namespace Gradium \
  --clientClassName GradiumClient \
  --targetFramework net10.0 \
  --output Generated \
  --security-scheme ApiKey:Header:x-api-key \
  --ignore-openapi-errors \
  --exclude-deprecated-operations

rm -rf ../../cli/Gradium.CLI

autosdk cli-project openapi.yaml \
  --output ../../cli/Gradium.CLI \
  --sdk-project ../../libs/Gradium/Gradium.csproj \
  --targetFramework net10.0 \
  --namespace Gradium \
  --clientClassName GradiumClient \
  --package-id Gradium.CLI \
  --tool-command-name gradium \
  --user-secrets-id Gradium.CLI \
  --api-key-env-var GRADIUM_API_KEY \
  --base-url-env-var GRADIUM_BASE_URL \
  --cli-credential-file \
  --exclude-deprecated-operations \
  --security-scheme ApiKey:Header:x-api-key \
  --ignore-openapi-errors
