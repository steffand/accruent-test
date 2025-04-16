describe('Movements Page', () => {
    it('should load the movements page', () => {
      cy.visit('http://localhost:4200');
      cy.contains('Movimentações');
    });
  });
  

  describe('Insert movement', () => {
    it('should insert the movement', () => {
      cy.visit('http://localhost:4200');
      cy.get('#productCode').type('A');
      cy.get('#quantity').type('2');
      cy.get('button[type=submit]').click();
      cy.contains('Movimentação registrada com sucesso!');
    });
  });