#!/bin/bash

if $1 $2; then
    echo "Build succeeded"
else
    echo "Failed as expected"
fi
