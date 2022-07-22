import { Container, Nav, Navbar, NavDropdown } from 'react-bootstrap'
import { NavLink } from 'react-router-dom'



const NavBar = () => {
  return (
    <>
      <Navbar bg="light" expand="lg">
        <Container>
          <Navbar.Brand as={NavLink} to="/">Reporting System</Navbar.Brand>
          <Navbar.Toggle aria-controls="basic-navbar-nav" />
          <Navbar.Collapse id="basic-navbar-nav">
            <Nav className="me-auto">
              <Nav.Link as={NavLink} to="/">Дефектоскопы</Nav.Link>
              <Nav.Link as={NavLink} to="/repairs">Ремонты</Nav.Link>
              <NavDropdown title="Дополнительно" id="basic-nav-dropdown">
                <NavDropdown.Item as={NavLink} to="/engineers">Электроники</NavDropdown.Item>
                <NavDropdown.Item as={NavLink} to="/organizations">Организации</NavDropdown.Item>
                <NavDropdown.Item as={NavLink} to="/type-of-defectoscopes">Типы Дефектоскопов</NavDropdown.Item>
              </NavDropdown>
            </Nav>
          </Navbar.Collapse>
        </Container>
      </Navbar>
    </>
  )
}

export default NavBar