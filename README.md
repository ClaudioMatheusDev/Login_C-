# Login_C- | Sistema de Login com Senha Criptografada em ASP.NET

Este projeto implementa um sistema de login simples utilizando ASP.NET, com funcionalidade de senha criptografada para garantir maior segurança.

## Funcionalidades

- **Cadastro de usuários:** Permite o registro de novos usuários no sistema.
- **Login seguro:** Realiza o login com validação de credenciais, utilizando senhas criptografadas para garantir a segurança.
- **Criptografia de senha:** Utiliza algoritmos de criptografia seguros para armazenar senhas no banco de dados.

## Tecnologias Utilizadas

- **ASP.NET:** Framework de desenvolvimento web da Microsoft.
- **C#:** Linguagem de programação utilizada para a lógica de backend.
- **SQL Server:** Banco de dados utilizado para armazenar informações de usuários e credenciais.

## Como Rodar o Projeto

1. **Clone o repositório:**
   ```bash
   git clone https://github.com/ClaudioMatheusDev/Login_C-.git
   ```

2. **Abra o projeto no Visual Studio:**
   Abra o arquivo `.sln` no Visual Studio para começar a trabalhar no projeto.

3. **Configuração do Banco de Dados:**
   O projeto usa um banco de dados SQL Server. Certifique-se de configurar a string de conexão corretamente no arquivo `appsettings.json`.

4. **Executar a aplicação:**
   - No Visual Studio, clique em "Iniciar" (ou pressione `F5`) para rodar a aplicação localmente.
   - A aplicação estará disponível em `http://localhost:{porta}`.

## Funcionalidade de Criptografia de Senha

Este sistema utiliza a classe `PasswordHasher` para criptografar as senhas dos usuários antes de armazená-las no banco de dados. Isso garante que as senhas nunca sejam armazenadas em texto claro.

## Contribuições

Se você deseja contribuir com o projeto, fique à vontade para enviar um pull request ou abrir uma issue no repositório.

## Licença

Este projeto está licenciado sob a MIT License - veja o arquivo [LICENSE](LICENSE) para mais detalhes.
