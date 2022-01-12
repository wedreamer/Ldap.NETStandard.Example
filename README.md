# Ldap.NETStandard.Example

## openLdap in docker

```bash
docker run -p 389:389 -p 636:636 --name my-openldap-container --detach osixia/openldap:1.4.0

docker exec my-openldap-container ldapsearch -x -H ldap://localhost -b dc=example,dc=org -D "cn=admin,dc=example,dc=org" -w admin
```

## install ldap-utils

ubuntu or wsl

```bash
sudo apt install ldap-utils
```
