import {
  AppBar,
  IconButton,
  Slide,
  Switch,
  Toolbar,
  Tooltip,
  Typography,
} from "@mui/material";
import { Box } from "@mui/system";

import { MuiTheme, useMuiTheme, useRoute } from "../GlobalProviders";
import ArrowBackIcon from "@mui/icons-material/ArrowBack";
import { useNavigate } from "react-router-dom";

const Header = () => {
  const { toggleLightDarkTheme, theme } = useMuiTheme();
  const { pageTitle } = useRoute();
  const navigate = useNavigate();
  const handleThemeSwitchClick = () => {
    toggleLightDarkTheme();
  };

  const handleGoBackButtonClick = () => {
    navigate("/customers");
  };

  return (
    <AppBar>
      <Toolbar>
        <Box display="flex" flexWrap="nowrap" flexGrow="1" alignItems="center">
          <Box display="flex" flexDirection="row" alignItems="center">
            <Typography>{pageTitle}</Typography>
            {pageTitle === "Sales Opportunities" && (
              <Tooltip title="Go back to previous page.">
                <IconButton
                  aria-label="Go back to previous page."
                  color="inherit"
                  size="large"
                  onClick={handleGoBackButtonClick}
                >
                  <ArrowBackIcon />
                </IconButton>
              </Tooltip>
            )}
          </Box>
        </Box>

        <Box>
          <Tooltip title={`Toggle light/dark mode - Currently ${theme} mode.`}>
            <Switch
              checked={theme === MuiTheme.Dark}
              onChange={handleThemeSwitchClick}
              inputProps={{
                "aria-label": `Toggle light/dark mode - Currently ${theme} mode.`,
              }}
            />
          </Tooltip>
        </Box>
      </Toolbar>
    </AppBar>
  );
};

export default Header;
