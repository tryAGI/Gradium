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
