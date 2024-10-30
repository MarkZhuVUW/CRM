import Person2Icon from "@mui/icons-material/Person2";
import {
  AppBar,
  Avatar,
  Grid,
  ListItemButton,
  Slide,
  Switch,
  Toolbar,
  Tooltip,
  Typography,
} from "@mui/material";
import { Box } from "@mui/system";
import { useState } from "react";
import { useNavigate } from "react-router-dom";
import {
  MuiTheme,
  useCustomer,
  useMuiTheme,
  useRoute,
} from "../GlobalProviders";

const Header = () => {
  const { toggleLightDarkTheme, theme } = useMuiTheme();

  const { pageTitle } = useRoute();

  const handleThemeSwitchClick = () => {
    toggleLightDarkTheme();
  };

  return (
    <AppBar>
      <Toolbar>
        <Box flexWrap="nowrap" flexGrow="1">
          {/* For decorative icons, set aira-hidden to true */}

          <Slide direction="right" in={true} timeout={500}>
            <Box display="flex" flexDirection="row" alignItems="center">
              <Typography>{pageTitle}</Typography>
            </Box>
          </Slide>
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
