export function getCurrentUrl(pathname: string) {
  return pathname.split(/[?#]/)[0]
}

export function checkIsActive(pathname: string, url: string) {
  const current = getCurrentUrl(pathname)
  if (!current || !url) {
    return false
  }

  // Exact match
  if (current === url) {
    return true
  }

  // Match url only if current starts with url + '/'
  if (current.startsWith(url + '/')) {
    return true
  }

  return false
}
