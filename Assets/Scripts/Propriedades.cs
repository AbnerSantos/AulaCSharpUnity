public class Propriedades
{

    // Em outras linguagens de programação, precisamos limitar acesso dessa forma:
    public class Pessoa
    {
        int idade;

        public int GetIdade()
        {
            return idade;
        }

        void SetIdade(int idade)
        {
            // Posso usar aqui para fazer algum tratamento, se for o caso
            // Por exemplo proibir idades negativas

            this.idade = idade;
        }
    }

    public class Casal
    {
        Pessoa pessoa1, pessoa2;

        int IdadeMedia()
        {
            // Não compila, SetIdade é privado
            // pessoa1.SetIdade(20);

            // Só acesso ao get, essa classe não deveria conseguir mudar a idade das pessoas
            return (pessoa1.GetIdade() + pessoa2.GetIdade()) / 2;
        }
    }

    // O C#, no entanto, tem propriedades. Que é bem melhor!
    public class PessoaMelhor
    {
        int idade;
        public int Idade
        {
            get
            {
                return idade;
            }
            private set // Tem como limitar para privado
            {
                // Posso usar aqui para fazer algum tratamento também
                idade = value;
            }
        }

        // Mesma coisa, só que mais curto
        public int Idade2 { get => idade; private set => idade = value; }

        // Auto-Properties, para getters e setters triviais (como os que estamos fazendo)
        public int Idade3 { get; private set; }

        // Isso é o jeito rápido de fazer apenas um getter, sem setter 
        public int Idade4 => idade; // Isso é o jeito rápido de fazer apenas um getter, sem setter
    }

    public class CasalMelhor
    {
        PessoaMelhor pessoa1, pessoa2;

        int IdadeMedia()
        {
            // Não compila, o set é privado
            // Idade = 20;

            // Acesso como se fosse uma variável normal
            return (pessoa1.Idade + pessoa2.Idade) / 2;
        }
    }
}