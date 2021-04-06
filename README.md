Projetos desenvolvidos para o MBA de Arqutitetura de Software

Force Map Count in Docker Desktop Windows
• open powershell
• wsl -d docker-desktop
• sysctl -w vm.max_map_count=262144
• echo "vm.max_map_count = 262144" > /etc/sysctl.d/99-docker-desktop.conf
• echo -e "\nvm.max_map_count = 262144\n" >> /etc/sysctl.d/00-alpine.conf