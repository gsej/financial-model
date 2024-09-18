import 'cypress-plugin-api'

describe('health', () => {
  it('should return 200', () => {
    cy.api('GET', '/health')
      .then(response => {
        expect(response.status).to.eq(200);
        expect(response.body).to.eq('Healthy');
      })
  })
})
