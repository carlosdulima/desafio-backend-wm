- Utilizei arquitetura hexagonal seguindo principios de clean code e solid

- Não me preocupei muito com o front, mas fiz pelo menos o básico, fiz em asp,net mvc para evitar conflitos de versões de npm e angularcli 
  e usei com jquery ajax

- Utilizei chamadas REST com Refit usando Polly como resiliência

- Utilizei um Repositório genérico com EF Core

- Eu iria implementar alguns testes unitários, mas por questão de tempo, não consegui

- Parametros, usei querystring que foi mais rápido, mas em um implementação real, usuario
  hidden criptogrado ao menos com um hash de chave simétrica e sempre composta, validando com o usuário autenticado
