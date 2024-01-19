#!/bin/bash
rm -f ./Infrastructure/Data/Migrations/*
rm -f ./Web/*.db
rm -f ./Web/*.db-shm
rm -f ./web/*.db-wal
dotnet ef migrations add InitialMigration --context ApplicationDbContext --startup-project Web --project Infrastructure -o Data/Migrations -- --environment development
dotnet ef database update --context ApplicationDbContext --startup-project Web --project Infrastructure -- --environment development


