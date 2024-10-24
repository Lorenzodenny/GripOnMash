1) Vista la doppia autenticazione tramite identity per i medici di base, quindi gli esterni
e Ldap per i medici interni per recuperare i claims salvati all'interno del cookie CookieAuth
e poter utilizzare le informazioni al suo interno, e per autorizzare determinate action o controller
solo a interni o determinati ruoli, degli interni utilizziamo 

[Authorize(Roles = "Admin", AuthenticationSchemes = "CookieAuth, Identity.Application")]

