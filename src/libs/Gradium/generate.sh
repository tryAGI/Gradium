#!/usr/bin/env bash
set -euo pipefail

dotnet tool install --global autosdk.cli --prerelease
rm -rf Generated
curl --fail --silent --show-error --location https://docs.gradium.ai/api-reference/openapi.json -o openapi.yaml

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
