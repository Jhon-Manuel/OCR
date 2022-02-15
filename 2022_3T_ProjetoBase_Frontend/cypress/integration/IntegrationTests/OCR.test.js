describe('Integracao - OCR', ()=>{

    beforeEach(() =>{
        cy.visit('http://localhost:3000')
    })

    It('Deve logar e inserir a imagem carregando a OCR no/ input de texto', () =>{

        cy.get('.cabecalhoPrincipal-nav-login').should('exist')
        cy.get('.cabecalhoPrinciapl-nav-login').click()

        cy.get('.input__login').first().type('teste@email.com')
        cy.get('.input__login').last().type('12345678')
        cy.get('.btn__login').click()

        cy.get('.input[type=file]').first().selectFile('sr/assets/tests/foto.jpeg')

        cy.wait(3000)
        cy.get('#codigoPatrimonio'.should('have.value', '//codigo do produto'))

    })
})