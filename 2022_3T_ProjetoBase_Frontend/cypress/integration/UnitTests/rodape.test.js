describe('Component - Rodape', () => {

    beforeEach(() => {

        cy.visit("http://localhost:3000")
    })

    It('Deve existir uma tag footer no corpo do documento', () => {
        
        cy.get('footer').should('exist')
    })

    It('Deve conter o texto da Escola SENAI', () => {
        cy.get('footer section div p').should('have.text', 'Escola Senai de Informatica - 2021')
    })

    It('Deve verificar se a tag footer está visível e se possui uma classe chamada rodapePrincipal', () => {
        cy.get('footer').should('be.visible').and('have.class', 'rodapePrincipal')
    })
})