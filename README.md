# 🌱 Ecoleta API

Uma API RESTful desenvolvida em .NET 8 para gerenciar um sistema de coleta de materiais recicláveis com sistema de pontos ecológicos.

## 📋 Sobre o Projeto

O Ecoleta é um sistema que conecta usuários e pontos de coleta (ecopontos) para facilitar a coleta de materiais recicláveis. Os usuários ganham EcoPoints ao realizar coletas e podem resgatar brindes com esses pontos.

### 🎯 Funcionalidades Principais

- **Gestão de Usuários**: Cadastro, autenticação e gerenciamento de perfis
- **Gestão de EcoPoints**: Sistema de pontos para coletas realizadas
- **Pontos de Coleta**: Cadastro e gerenciamento de ecopontos
- **Sistema de Coletas**: Registro e acompanhamento de coletas de materiais
- **Sistema de Brindes**: Catálogo de brindes disponíveis para resgate
- **Sistema de Resgates**: Troca de EcoPoints por brindes

## 🛠 Tecnologias Utilizadas

- **.NET 8** - Framework principal
- **ASP.NET Core Web API** - Para criação da API REST
- **Entity Framework Core** - ORM para acesso a dados
- **SQL Server** - Banco de dados
- **Swagger/OpenAPI** - Documentação da API
- **Newtonsoft.Json** - Serialização JSON com suporte a loops de referência

## 🏗 Arquitetura

O projeto segue uma arquitetura em camadas com separação de responsabilidades:

```
├── Controllers/     # Controladores da API
├── Services/        # Lógica de negócio
├── Repository/      # Camada de acesso a dados
├── Models/          # Modelos de dados
├── Data/           # Contexto do banco de dados
├── Utils/          # Utilitários (criptografia)
└── Migrations/     # Migrações do Entity Framework
```

## 📊 Modelos de Dados

### UtilizadorModel
- **IdUtilizador**: Identificador único
- **Nome**: Nome do usuário
- **Email**: E-mail do usuário
- **Username**: Nome de usuário
- **TotalEcoPoints**: Total de pontos ecológicos
- **Latitude/Longitude**: Localização do usuário
- **PasswordHash/PasswordSalt**: Senha criptografada

### EcopontoModel
- **IdEcoponto**: Identificador único
- **Nome**: Nome do ecoponto
- **CNPJ**: CNPJ da empresa
- **RazaoSocial**: Razão social
- **Endereço completo**: Logradouro, número, bairro, cidade, UF, CEP
- **Latitude/Longitude**: Localização do ecoponto
- **Credenciais**: Username, email e senha criptografada

### ColetaModel
- **IdColeta**: Identificador único
- **IdEcoponto**: Referência ao ecoponto
- **IdUtilizador**: Referência ao usuário
- **Classe**: Tipo de material coletado (enum)
- **DataColeta**: Data da coleta
- **Peso**: Peso do material coletado
- **SituacaoColeta**: Status da coleta

### BrindeModel
- **IdBrinde**: Identificador único
- **NomeBrinde**: Nome do brinde
- **DescricaoBrinde**: Descrição detalhada
- **ValorEcopoints**: Pontos necessários para resgate
- **Quantidade**: Quantidade disponível
- **Validade**: Data de validade

### ResgateModel
- **IdResgate**: Identificador único
- **IdUtilizador**: Referência ao usuário
- **IdBrinde**: Referência ao brinde
- **DataResgate**: Data do resgate

## 🗂 Tipos de Materiais

O sistema suporta os seguintes tipos de materiais (enum Materiais):

1. **Papel**
2. **Plástico**
3. **Vidro**
4. **Metal**
5. **Orgânico**
6. **Eletrônico**
7. **Pilha**
8. **Bateria**
9. **Óleo**
10. **Medicamento**
11. **Outro**

## 🔗 Endpoints da API

### Usuários (`/api/Utilizador`)
- `GET /GetAll` - Lista todos os usuários
- `GET /GetbyId/{id}` - Busca usuário por ID
- `POST /Post` - Cria novo usuário
- `PUT /Put/{username}` - Atualiza usuário
- `DELETE /Delete/{id}` - Remove usuário
- `POST /Registrar` - Registra novo usuário
- `POST /Autenticar` - Autentica usuário
- `PUT /AlterarSenha` - Altera senha do usuário
- `PUT /AtualizarEmail` - Atualiza email do usuário
- `POST /ResgatarBrinde/{idUtilizador}/{idBrinde}` - Resgata brinde

### EcoPoints (`/api/EcoPonto`)
- `GET /GetAll` - Lista todos os ecopontos
- `GET /GetbyId/{IdEcoponto}` - Busca ecoponto por ID
- `POST /Post` - Cria novo ecoponto
- `PUT /Put/{username}` - Atualiza ecoponto
- `DELETE /Delete/{IdEcoponto}` - Remove ecoponto
- `POST /CadastrarEcoponto` - Cadastra novo ecoponto
- `POST /AutenticarEcoponto` - Autentica ecoponto
- `PUT /AlterarSenha` - Altera senha do ecoponto
- `PUT /AlterarEmail` - Atualiza email do ecoponto

### Coletas (`/api/Coleta`)
- `GET /GetAll` - Lista todas as coletas
- `GET /GetId/{IdColeta}` - Busca coleta por ID
- Outros endpoints para gerenciamento de coletas

### Brindes (`/api/Brinde`)
- Endpoints para gerenciamento de brindes

### Resgates (`/api/Resgate`)
- `GET /GetAll` - Lista todos os resgates
- `GET /GetbyId` - Busca resgate por ID
- Outros endpoints para gerenciamento de resgates

## 🔒 Segurança

- **Criptografia de Senhas**: Utiliza HMACSHA512 para hash das senhas
- **Salt**: Cada senha possui um salt único para maior segurança
- **Validação de Dados**: Validações nos modelos e controladores

## 🗄 Banco de Dados

### Configuração de Conexão
O projeto está configurado para trabalhar com duas strings de conexão:
- **ConexaoLocal**: Servidor SQL Server local
- **ConexaoSomee**: Servidor de produção (Somee)

### Tabelas Principais
- `TB_UTILIZADOR` - Usuários do sistema
- `TB_ECOPONTO` - Pontos de coleta
- `TB_COLETA` - Registros de coletas
- `TB_BRINDE` - Catálogo de brindes
- `TB_RESGATE` - Histórico de resgates

### Dados de Teste (Seed Data)
O sistema inclui dados iniciais para desenvolvimento:
- 3 usuários (incluindo admin)
- 2 ecopontos
- 2 coletas de exemplo
- 2 brindes disponíveis
- 2 resgates de exemplo

## 🚀 Como Executar

### Pré-requisitos
- .NET 8 SDK
- SQL Server (LocalDB ou instância completa)
- Visual Studio ou VS Code

### Configuração

1. **Clone o repositório**
```bash
git clone [url-do-repositorio]
cd api
```

2. **Configure a string de conexão**
Edite o arquivo `appsettings.json` com suas configurações de banco:
```json
{
  "ConnectionStrings": {
    "ConexaoLocal": "Data Source=localhost; Initial Catalog=DB_DS_SUSTENTECH; User Id=sa; Password=sua_senha;TrustServerCertificate=True"
  }
}
```

3. **Restore os pacotes**
```bash
dotnet restore
```

4. **Execute as migrações**
```bash
dotnet ef database update
```

5. **Execute a aplicação**
```bash
dotnet run
```

6. **Acesse a documentação Swagger**
Abra o navegador em: `https://localhost:7xxx/swagger`

## 📝 Padrões de Desenvolvimento

### Injeção de Dependência
O projeto utiliza injeção de dependência nativa do .NET Core para:
- Services (lógica de negócio)
- Repositories (acesso a dados)
- DbContext (Entity Framework)

### Tratamento de Erros
- Status codes HTTP apropriados
- Try-catch em operações críticas
- Responses padronizados

### Documentação
- Swagger/OpenAPI integrado
- Atributos ProducesResponseType para documentar retornos
- Comentários nos endpoints

## 🤝 Contribuição

1. Faça um fork do projeto
2. Crie uma branch para sua feature (`git checkout -b feature/AmazingFeature`)
3. Commit suas mudanças (`git commit -m 'Add some AmazingFeature'`)
4. Push para a branch (`git push origin feature/AmazingFeature`)
5. Abra um Pull Request

## 📋 TODO / Melhorias Futuras

- [ ] Implementar autenticação JWT
- [ ] Adicionar autorização baseada em roles
- [ ] Implementar cache Redis
- [ ] Adicionar logs estruturados
- [ ] Implementar testes unitários
- [ ] Adicionar validações mais robustas
- [ ] Implementar paginação nos endpoints
- [ ] Adicionar filtros e ordenação
- [ ] Implementar upload de imagens
- [ ] Adicionar notificações push

## 📄 Licença

Este projeto está sob a licença MIT. Veja o arquivo [LICENSE](LICENSE) para mais detalhes.

## 📞 Contato

Para dúvidas ou sugestões sobre o projeto, entre em contato através dos issues do GitHub.

---

**Desenvolvido com 💚 para um mundo mais sustentável**
