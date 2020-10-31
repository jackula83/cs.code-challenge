import React, { Component } from 'react';
import {
  Collapse,
  Container,
  Navbar,
  NavbarBrand,
  NavbarToggler,
  NavLink,
} from 'reactstrap';
import { Link } from 'react-router-dom';

class NavMenu extends Component {
  static displayName = NavMenu.name;

  constructor(props) {
    super(props);

    this.toggleNavbar = this.toggleNavbar.bind(this);
    this.state = {
      collapsed: true,
    };
  }

  toggleNavbar() {
    this.setState({
      collapsed: !this.state.collapsed,
    });
  }

  render() {
    return (
      <header>
        <Navbar className="navbar-expand-sm navbar-toggleable-sm bg-dark navbar-dark movable">
          <Container>
            <NavbarBrand to="/">CarSales</NavbarBrand>
            <NavbarToggler onClick={this.toggleNavbar} className="mr-2" />
            <Collapse
              // className="d-sm-inline-flex flex-sm-row-reverse"
              isOpen={!this.state.collapsed}
              navbar
            >
              <React.Fragment>
                <div className="navbar-nav ml-auto">
                  <NavLink tag={Link} className="nav-item nav-link" to="/">
                    <i className="fa fa-user mx-2"></i>
                    New Customer
                  </NavLink>
                  <NavLink
                    tag={Link}
                    className="nav-item nav-link"
                    to="/roster"
                  >
                    <i className="fa fa-exclamation mx-2"></i>
                    Reset State
                  </NavLink>
                </div>
              </React.Fragment>
            </Collapse>
          </Container>
        </Navbar>
      </header>
    );
  }
}

export default NavMenu;
