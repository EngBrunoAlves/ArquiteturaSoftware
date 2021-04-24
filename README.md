Projetos desenvolvidos para o MBA de Arqutitetura de Software

Force Map Count in Docker Desktop Windows
• open powershell
• wsl -d docker-desktop
• sysctl -w vm.max_map_count=262144
• echo "vm.max_map_count = 262144" > /etc/sysctl.d/99-docker-desktop.conf
• echo -e "\nvm.max_map_count = 262144\n" >> /etc/sysctl.d/00-alpine.conf


https://medium.com/@mandeep_m91/setting-up-elasticsearch-and-kibana-on-docker-with-x-pack-security-enabled-6875b63902e6

Configure Secure in XPack-Security
• Change elasticsearch/cert/elasticsearch.yml to xpack.security.enabled: false
• docker cp a2d58ac87c0e485c1eae56ef0b8e51b9ee27c6a9c17c2ed0ea0957c9af2bf7da:/usr/share/elasticsearch/elastic-certificates.p12 .
• docker cp a2d58ac87c0e485c1eae56ef0b8e51b9ee27c6a9c17c2ed0ea0957c9af2bf7da:/usr/share/elasticsearch/elastic-stack-ca.p12 .
• Move *.p12 to folder elasticsearch/cert
• Change elasticsearch/cert/elasticsearch.yml to xpack.security.enabled: true

Generates the default User and Password
