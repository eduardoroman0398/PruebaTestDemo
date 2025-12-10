Feature: Login de usuario

Background:
	Given que el usuario ingresa al ambiente "UAT"

Scenario Outline: Login exitoso
	When Ingreso el usuario "<user>" y la contrasenia "<password>"
	And el usuario hace clic en el boton de iniciar sesion
	Then Valido que el login sea exitoso
Examples:
	| user                   | password |
	| albop_can1@yopmail.com | 12345678 |

Scenario Outline: Login fallido
	When Ingreso el usuario "<user>" y la contrasenia "<password>"
	And el usuario hace clic en el boton de iniciar sesion
	Then Valido que el login sea fallido
Examples:
	| user                    | password |
	| albop_can1@yopmail.comm | 87654321 |