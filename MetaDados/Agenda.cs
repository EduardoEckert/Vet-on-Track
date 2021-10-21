using System;

namespace MetaDados
{
    public class Agenda : Pet
    {
        public int id_agenda { get; set; }

        public int id_servico { get; set; }

        public DateTime hr_agenda { get; set; }

        public string string_horario { get; set; }

        public int id_funcionario { get; set; }

        public Agenda() { }

        public Agenda(int id_cliente, int id_pet, int id_servico, DateTime hr_agenda, int id_funcionario)
        {
            this.id_servico = id_servico;
            this.hr_agenda = hr_agenda;
            this.id_cliente = id_cliente;
            this.id_pet = id_pet;
            this.id_funcionario = id_funcionario;
        }

    }
}
