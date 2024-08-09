import { MenuItem } from "primereact/menuitem";

export const sidebarData = [
  {
    id: "Pre-Sale",
    label: "Pre-Sale",
    items: [
      {
        label: "Openning Stock Add",
        icon: "pi pi-fw pi-plus",
        url: "/openingstockadd",
      },
      {
        label: "Vehicle Arrived Entry",
        icon: "pi pi-fw pi-download",
        url: "/vehiclearrived",
      },
      {
        label: "Battrey Add",
        icon: "pi pi-fw pi-plus",
        url: "/batteryadd",
      },
    ],
  },
  {
    id: "Sale",
    label: "Sale",
    items: [
      {
        label: "Vehicle Booking",
        icon: "pi pi-fw pi-refresh",
        url: "/vehiclebooking",
      },
      {
        label: "Vehicle Selection",
        icon: "pi pi-fw pi-repeat",
        url: "/vehicleselection",
      },
      {
        label: "Vehicle De-Selection",
        icon: "pi pi-fw pi-book",
        url: "/vehiclede-selection",
      },
      {
        label: "Accessories & Battery Issue",
        icon: "pi pi-fw pi-search",
        url: "/accessories&batteryissue",
      },
    ],
  },
] as MenuItem[];

export const headerData = [
  {
    label: "",
    icon: "pi pi-bars",
    className: "p-button-rounded p-button-secondary",
  },
  {
    label: "Live Dashboard",
    className: "p-button-text p-button-md text-0",
    url: "/serviceLivestatus",
  },
  {
    label: "Settings",
    icon: "pi pi-fw pi-cog",
    items: [
      {
        label: "Update Profile",
        icon: "pi pi-user-edit",
      },
      {
        label: "Change Password",
        icon: "pi pi-cog",
        url: "/forgot-password",
      },
      {
        label: "Logout",
        icon: "pi pi-sign-out",
        url: "/",
      },
    ],
  },
] as MenuItem[];
