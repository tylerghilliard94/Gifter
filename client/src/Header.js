import React from "react";
import { NavLink, BrowserRouter as Router } from "react-router-dom";

const Header = () => {
    return (

        <nav className="navbar navbar-expand navbar-dark bg-info">
            <NavLink to="/" className="navbar-brand">
                GiFTER
      </NavLink>
            <ul className="navbar-nav mr-auto">
                <li className="nav-item">
                    <NavLink to="/" className="nav-link">
                        Feed
          </NavLink>
                </li>
                <li className="nav-item">
                    <NavLink to="/posts/add" className="nav-link">
                        New Post
          </NavLink>
                </li>
            </ul>
        </nav>

    );
};

export default Header;