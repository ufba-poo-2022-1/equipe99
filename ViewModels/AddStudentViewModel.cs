﻿using System.Reactive;
using gerenciador.escolar.Models;
using ReactiveUI;

namespace gerenciador.escolar.ViewModels;

/// <summary>
/// Classe responsável pelo comportamento da tela de adição de estudante.
/// </summary>
public class AddStudentViewModel : ReactiveObject
{

    /// <summary>
    /// Construtor da AddStudentViewModel onde é verificado se existe um valor na property
    /// Name, havendo este valor fica liberado pressionar o botão OK, aqui também se define
    /// o comportamento para o botão de Ok bem como o comportamento para o botão de Cancelamento.
    /// TODO: criar adição de disciplinas, representando as classes que o mesmo frenquenta aula.
    /// </summary>
    public AddStudentViewModel()
    {
        var okEnabled = this.WhenAnyValue(
            x => x.Name,
            x => !string.IsNullOrWhiteSpace(x));

        Ok = ReactiveCommand.Create(
                () => new Student(Name), 
                okEnabled);
        Cancel = ReactiveCommand.Create(() => { });
    }

    /// <summary>
    /// field(campo) que armazena o valor do nome inputado na tela de adição de estudante
    /// </summary>
    string? name;

    /// <summary>
    /// property(propriedade) que dá acesso ao o nome inputado na tela de adição de estudante
    /// </summary>
    public string Name 
    {
        get => name!;
        set => this.RaiseAndSetIfChanged(ref name, value);
    }
   
    /// <summary>
    /// property(propriedade) que controla a ação do botão de Ok 
    /// </summary>
    public ReactiveCommand<Unit, Student> Ok { get; }
    
    /// <summary>
    /// property(propriedade) que controla a ação do botão de Cancelamento
    /// </summary>
    public ReactiveCommand<Unit, Unit> Cancel { get; }

}
