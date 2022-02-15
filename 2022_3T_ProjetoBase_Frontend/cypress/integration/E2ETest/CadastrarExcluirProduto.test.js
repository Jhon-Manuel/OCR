describe('End2End', () =>{

    beforeEach(() => {
        cy.visit('http://localhost:3000')
    })

    It('Deve cadastrar uma imagem', () => {

        cy.get('.cabecalhoPrincipal-nav-login').should('exist')
        cy.get('.cabecalhoPrinciapl-nav-login').click()

        cy.get('.input__login').first().type('teste@email.com')
        cy.get('.input__login').last().type('12345678')
        cy.get('.btn__login').click()

        cy.get('.multipart/form-data').should('exists')
        cy.get('.multipart/form-data').click()

        cy.get('input__login').type('ficticio')
        cy.get('input__login').type('have.value', '1233')
        cy.get('.input[type=file]').first().selectFile('sr/assets/tests/fototeste.jpeg')

        cy.get('btn__cadastro').click()

    })

    It('Deve excluit uma imgem', () => {

        cy.get('.cabecalhoPrincipal-nav-login').should('exist')
        cy.get('.cabecalhoPrinciapl-nav-login').click()

        cy.get('.input__login').first().type('teste@email.com')
        cy.get('.input__login').last().type('12345678')
        cy.get('.btn__login').click()

        cy.get('.card').should('exist')
        cy.get('.card').click()
        cy.get('.excluir').type('have.value', '1233')
        cy.get('.excluir').click()


    })
})