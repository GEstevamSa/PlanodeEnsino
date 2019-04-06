import { AbstractControl } from '../../node_modules/@angular/forms';

export class Validacoes {
  static ValidaCpf(controle: AbstractControl) {
    const cpf = controle.value;

    let soma: number = 0;
    let resto: number;
    let valido: boolean;

    const regex = new RegExp('[0-9]{11}');

    if (
// tslint:disable-next-line: triple-equals
      cpf == '00000000000' ||
// tslint:disable-next-line: triple-equals
      cpf == '11111111111' ||
// tslint:disable-next-line: triple-equals
      cpf == '22222222222' ||
// tslint:disable-next-line: triple-equals
      cpf == '33333333333' ||
// tslint:disable-next-line: triple-equals
      cpf == '44444444444' ||
// tslint:disable-next-line: triple-equals
      cpf == '55555555555' ||
// tslint:disable-next-line: triple-equals
      cpf == '66666666666' ||
// tslint:disable-next-line: triple-equals
      cpf == '77777777777' ||
// tslint:disable-next-line: triple-equals
      cpf == '88888888888' ||
// tslint:disable-next-line: triple-equals
      cpf == '99999999999' ||
      !regex.test(cpf)
    ) {
      valido = false;
    } else {
      for (let i = 1; i <= 9; i++) {
// tslint:disable-next-line: radix
        soma = soma + parseInt(cpf.substring(i - 1, i)) * (11 - i);
      }
      resto = (soma * 10) % 11;

// tslint:disable-next-line: triple-equals
      if (resto == 10 || resto == 11) { resto = 0; }
// tslint:disable-next-line: radix
// tslint:disable-next-line: triple-equals
// tslint:disable-next-line: radix
      if (resto != parseInt(cpf.substring(9, 10))) { valido = false; }

      soma = 0;
      for (let i = 1; i <= 10; i++) {
// tslint:disable-next-line: radix
        soma = soma + parseInt(cpf.substring(i - 1, i)) * (12 - i);
      }
      resto = (soma * 10) % 11;

      if (resto == 10 || resto == 11) { resto = 0; }
// tslint:disable-next-line: radix
      if (resto != parseInt(cpf.substring(10, 11))) { valido = false; }
      valido = true;
    }

    if (valido) { return null; }

    return { cpfInvalido: true };
  }

  static MaiorQue18Anos(controle: AbstractControl) {
    const nascimento = controle.value;
    const [ano, mes, dia] = nascimento.split('-');
    const hoje = new Date();
    const dataNascimento = new Date(ano, mes, dia, 0, 0, 0);
    const tempoParaTeste = 1000 * 60 * 60 * 24 * 365 * 18;

    if (hoje.getTime() - dataNascimento.getTime() >= tempoParaTeste) {
      return null;
    }

    return { menorDeIdade: true };
  }

  static SenhasCombinam(controle: AbstractControl) {
    const senha = controle.get('senha').value;
    const confirmarSenha = controle.get('confirmarSenha').value;

    if (senha === confirmarSenha) { return null; }

    controle.get('confirmarSenha').setErrors({ senhasNaoCoincidem: true });
  }
}
